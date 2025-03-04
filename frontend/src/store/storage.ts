import { JWT_PERSISTENT_STATE } from "../config/config";
import { UserPersistentState } from "../interfaces/authInterface";

export function loadJwtState(key: string): UserPersistentState | undefined {
	try {
		const jsonState = localStorage.getItem(key);
		if (!jsonState) {
			return undefined;
		}
		return JSON.parse(jsonState);
	} catch (error) {
		console.error(error);
		return undefined;
	}
}

export function saveJwtState(state: UserPersistentState) {
	const stringState = JSON.stringify(state);
	localStorage.setItem(JWT_PERSISTENT_STATE, stringState);
}