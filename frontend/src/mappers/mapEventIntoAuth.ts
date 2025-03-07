import { Profile } from "../interfaces/authInterface";

export const mapEventIntoAuth = (event: React.FormEvent<HTMLFormElement>) => {
    const formElements = event.currentTarget.elements;
    const email = (formElements.namedItem("email") as HTMLInputElement).value;
    const password = (formElements.namedItem("password") as HTMLInputElement).value;
    const user: Profile = {
        email: email,
        password: password
    }
    return user;
}