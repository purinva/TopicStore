import { useDispatch } from "react-redux";
import { AppDispatch, store } from "../../store/store";
import { useNavigate } from "react-router-dom";
import { register } from "../../store/authSlice";
import { mapEventIntoAuth } from "../../mappers/mapEventIntoAuth";

export function RegisterPage() {

    const dispatch = useDispatch<AppDispatch>();
    const registerError = store.getState().auth.loginError;
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const user = mapEventIntoAuth(event);
        await dispatch(register(user));
        if (!registerError) {
            navigate("auth");
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
                {registerError && <div>registerError</div>}
            </div>
            <div>
                <button onClick={() => navigate("auth")}>Войти</button>
            </div>
        </div>
    )
}