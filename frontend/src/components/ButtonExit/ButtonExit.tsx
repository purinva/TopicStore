import { useDispatch } from "react-redux";
import { AppDispatch } from "../../store/store";
import { authActions } from "../../store/authSlice";
import { useNavigate } from "react-router-dom";

function ButtonExit() {

    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();

    const handleClick = () => {
        dispatch(authActions.logout());
        navigate('/auth/login');
    }

    return (
        <button onClick={handleClick}>Выйти</button>
    )
}

export default ButtonExit;