import { useDispatch } from "react-redux";
import { AppDispatch, store } from "../../store/store";
import { useNavigate } from "react-router-dom";
import { Profile } from "../../interfaces/authInterface";
import { register } from "../../store/authSlice";

export function RegisterPage() {

    const dispatch = useDispatch<AppDispatch>();
    const registerError = store.getState().auth.loginError;
    const navigate = useNavigate();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        const formElements = event.currentTarget.elements;
        const email = (formElements.namedItem("email") as HTMLInputElement).value;
        const password = (formElements.namedItem("password") as HTMLInputElement).value;
        const user: Profile = {
            email: email,
            password: password
        }
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