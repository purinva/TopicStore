import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { Topic, TopicCreateDto, TopicState, TopicUpdateDto } from "../interfaces/topicInterface";
import { store } from "./store";

const initialState: TopicState = {
  items: [],
  topic: null,
  totalPages: 0,
  getTopicsError: null,
  getTotalError: null,
  getTopicByIdError: null,
  createTopicError: null,
  updateTopicError: null,
  deleteTopicError: null
};

export const getTopics = createAsyncThunk<Topic[], number>(
  "topic/getTopics",
  async (page, { rejectWithValue }) => {
    try {
        const jwt = store.getState().auth.jwt;
        const response = await axios.get(`${URL}/topic?page=${page}`, {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });
        return response.data;
    } catch (error) {
      const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
    }
  }
);

export const getTotal = createAsyncThunk<number>(
  "topic/getTotal",
  async (_, { rejectWithValue }) => {
    try {
        const jwt = store.getState().auth.jwt;
        const response = await axios.get(`${URL}/topic/total`, {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });
        return response.data;
    } catch (error) {
      const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
    }
  }
);

export const getTopicById = createAsyncThunk<Topic, string>(
  "topic/getTopicById",
  async (topicId, { rejectWithValue }) => {
    try {
        const jwt = store.getState().auth.jwt;
        const response = await axios.get(`${URL}/topic/${topicId}`, {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });
        return response.data;
    } catch (error ) {
      const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
    }
  }
);

export const updateTopic = createAsyncThunk<Topic, TopicUpdateDto>(
  "topic/updateTopic",
  async (topicUpdateDto, { rejectWithValue }) => {
    try {
        const jwt = store.getState().auth.jwt;
        const response = await axios.patch(`${URL}/topic`,
          topicUpdateDto,
          {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });
        return response.data;
    } catch (error) {
      const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
    }
  }
);

export const createTopic = createAsyncThunk<Topic, TopicCreateDto>(
  "topic/createTopic",
  async (topicCreateDto, { rejectWithValue }) => {
    try {
        const jwt = store.getState().auth.jwt;
        const response = await axios.post(`${URL}/topic`,
          topicCreateDto,
          {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });
        return response.data;
    } catch (error) {
      const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
    }
  }
);

export const deleteTopic = createAsyncThunk<string, string>(
  "topic/deleteTopic",
  async (topicId, { rejectWithValue }) => {
    try {
        const jwt = store.getState().auth.jwt;
        await axios.delete(`${URL}/topic/${topicId}`,
          {
            headers: {
                Authorization: `Bearer ${jwt}`
            }
        });
        return topicId;
    } catch (error) {
      const axiosError = error as AxiosError<{ message: string }>;
			return rejectWithValue(axiosError.response?.data?.message || "Произошла ошибка, попробуйте снова.");
    }
  }
);

const topicSlice = createSlice({
  name: "topic",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getTopics.fulfilled, (state, action) => {
        state.items = action.payload;
        state.getTopicsError = null;
      })
      .addCase(getTopics.rejected, (state, action) => {
        state.getTopicsError = action.payload as string;
      });

    builder
      .addCase(getTotal.fulfilled, (state, action) => {
        state.totalPages = action.payload;
        state.getTotalError = null;
      })
      .addCase(getTotal.rejected, (state, action) => {
        state.getTotalError = action.payload as string;
      });

    builder
      .addCase(getTopicById.fulfilled, (state, action) => {
        state.topic = action.payload;
        state.getTopicByIdError = null;
      })
      .addCase(getTopicById.rejected, (state, action) => {
        state.getTopicByIdError = action.payload as string;
      });

    builder
      .addCase(updateTopic.fulfilled, (state, action) => {
        const updateTopicId = action.payload.topicId;
        const index = state.items.findIndex((topic) => topic.topicId === updateTopicId);
        state.items[index] = action.payload;
        state.updateTopicError = null;
      })
      .addCase(updateTopic.rejected, (state, action) => {
        state.updateTopicError = action.payload as string;
      });

    builder
      .addCase(createTopic.fulfilled, (state, action) => {
        state.items.push(action.payload);
        state.createTopicError = null;
      })
      .addCase(createTopic.rejected, (state, action) => {
        state.createTopicError = action.payload as string;
      });

    builder
      .addCase(deleteTopic.fulfilled, (state, action) => {
        const topicId = action.payload;
        state.items = state.items.filter(topic => topic.topicId !== topicId);
        state.deleteTopicError = null;
      })
      .addCase(deleteTopic.rejected, (state, action) => {
        state.deleteTopicError = action.payload as string;
      });
  }
});

export default topicSlice.reducer;
export const topicActions = topicSlice.actions;