import { configureStore } from '@reduxjs/toolkit';
import  authReducer from './authSlice.ts';
import { saveJwtState } from './storage.ts';
import topicReducer from './topicSlice.ts';

export const store = configureStore({
  reducer: {
    auth: authReducer,
    topic: topicReducer
  },
});

store.subscribe(() => {
	saveJwtState({ jwt: store.getState().auth.jwt });
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;