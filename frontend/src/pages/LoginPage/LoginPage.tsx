import { useDispatch } from "react-redux"
import { login } from "../../store/authSlice";
import React from "react";
import { Profile } from "../../interfaces/authInterface";
import { AppDispatch, store } from "../../store/store";
import { useNavigate } from "react-router-dom";

export function LoginPage() {

    const dispatch = useDispatch<AppDispatch>();
    const loginError = store.getState().auth.loginError;
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        const formElements = event.currentTarget.elements;
        const email = (formElements.namedItem("email") as HTMLInputElement).value;
        const password = (formElements.namedItem("password") as HTMLInputElement).value;
        const user: Profile = {
            email: email,
            password: password
        }
        await dispatch(login(user));
        if (!loginError) {
            navigate("topic");
        }
    }

    return (
        <div>
            <div>
                <form onSubmit={handleSubmit}>
                    <input type="text" name="email" placeholder="Введите email"/>
                    <input type="text" name="password" placeholder="Введите пароль"/>
                    <button type="submit"></button>
                </form>
                {loginError && <div>loginError</div>}
            </div>
            <div>
                <button onClick={() => navigate("auth/register")}>Зарегистрироваться</button>
            </div>
        </div>
    )
}