export interface Profile {
	email: string;
	password: string;
}

export interface AuthResponse {
	jwt: string
}

export interface UserState {
	jwt: string | null;
	error: string | null;
}

export interface UserPersistentState {
	jwt: string | null;
}