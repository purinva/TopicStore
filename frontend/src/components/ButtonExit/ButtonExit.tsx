import { useDispatch } from "react-redux";
import { AppDispatch } from "../../store/store";
import { authActions } from "../../store/authSlice";
import { useNavigate } from "react-router-dom";

export function ButtonExit() {

    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();

    return (
        <button onClick={() => {
            dispatch(authActions.logout());
            navigate('/auth/login');
        }}>
            Выйти
        </button>
    )
}