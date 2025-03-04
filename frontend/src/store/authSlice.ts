import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { JWT_PERSISTENT_STATE, URL } from "../config/config";
import { AuthResponse, Profile, UserState } from "../interfaces/authInterface";
import { loadJwtState } from "./storage";

const initialState: UserState = {
	jwt: loadJwtState(JWT_PERSISTENT_STATE)?.jwt ?? null,
	error: null
};

const login = createAsyncThunk<string, Profile>('auth/login',
	async (profile, { rejectWithValue }) => {
		try {
			const response = await axios.post<AuthResponse>(`${URL}/auth/login`, {
				email: profile.email,
				password: profile.password
			});
			return response.data.jwt;
		} catch (error) {
			const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
		}
	}
);

const register = createAsyncThunk<string, Profile>('auth/register',
	async (profile, { rejectWithValue }) => {
		try {
			const response = await axios.post<AuthResponse>(`${URL}/auth/register`, {
				email: profile.email,
				password: profile.password,
			});
			return response.data.jwt;
		} catch (error) {
			const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
		}
	}
);

const authSlice = createSlice({
	name: 'auth',
	initialState,
	reducers: {
		logout: (state) => {
			state.jwt = null;
			state.error = null;
		}
	},
	extraReducers: (builder) => {
		builder
			.addCase(login.fulfilled, (state, action) => {
				state.jwt = action.payload;
				state.error = null;
			})
			.addCase(login.rejected, (state, action) => {
				state.jwt = null;
				state.error = action.payload as string;
			});

		builder
			.addCase(register.fulfilled, (state, action) => {
				state.jwt = action.payload;
				state.error = null;
			})
			.addCase(register.rejected, (state, action) => {
				state.jwt = null;
				state.error = action.payload as string;
			});
	}
});

export default authSlice.reducer;
export const authActions = authSlice.actions;