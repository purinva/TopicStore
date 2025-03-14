import { useDispatch, useSelector } from "react-redux"
import { login } from "../../store/authSlice";
import React from "react";
import { AppDispatch, RootState } from "../../store/store";
import { useNavigate } from "react-router-dom";
import { mapEventIntoAuth } from "../../mappers/mapEventIntoAuth";

export function LoginPage() {

    const dispatch = useDispatch<AppDispatch>();
    const loginError = useSelector((state: RootState) => state.auth.loginError);
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const user = mapEventIntoAuth(event);
        const result = await dispatch(login(user));
        if (login.fulfilled.match(result)) {
            navigate("/topic");
        }
    }

    return (
        <div>
            <div>
                <form onSubmit={handleSubmit}>
                    <input type="text" name="email" placeholder="Введите email"/>
                    <input type="text" name="password" placeholder="Введите пароль"/>
                    <button type="submit">Войти</button>
                </form>
                {loginError && <div>{loginError}</div>}
            </div>
            <div>
                <button onClick={() => navigate("register")}>Зарегистрироваться</button>
            </div>
        </div>
    )
}