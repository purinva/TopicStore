export interface Profile {
	email: string;
	password: string;
}

export interface AuthResponse {
	token: string
}

export interface UserState {
	jwt: string | null;
	loginError: string | null;
	registerError: string | null;
}

export interface UserPersistentState {
	jwt: string | null;
}