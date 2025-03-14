import { useEffect } from "react"
import { useDispatch } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { AppDispatch } from "../../store/store";
import { getTopicById, updateTopic } from "../../store/topicSlice";
import { mapEventIntoTopicUpdateDto } from "../../mappers/mapEventIntoTopic";

export function TopicByIdPage() {

    const { topicId } = useParams();
    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();

    useEffect(() => {
        dispatch(getTopicById(topicId as string));
    }, [dispatch, topicId])

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const topic = mapEventIntoTopicUpdateDto(event, topicId as string);
        await dispatch(updateTopic(topic));
        navigate("/topic");
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="text" name="title"/>
                <input type="text" name="description"/>
                <input type="date" name="date"/>
                <button type="submit">Изменить</button>
            </form>
            <button onClick={() => navigate("/topic")}>Назад</button>
        </div>
    )
}