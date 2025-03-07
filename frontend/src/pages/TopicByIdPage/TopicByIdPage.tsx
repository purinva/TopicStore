import { useEffect } from "react"
import { useDispatch } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { AppDispatch, store } from "../../store/store";
import { createTopic, getTopicById } from "../../store/topicSlice";
import { mapEventIntoTopic } from "../../mappers/mapEventIntoTopic";

export function TopicByIdPage() {

    const { topicId } = useParams();
    const dispatch = useDispatch<AppDispatch>();
    const topic = store.getState().topic.topic;
    const navigate = useNavigate();

    useEffect(() => {
        dispatch(getTopicById(topicId as string));
    }, [dispatch, topicId])

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const topic = mapEventIntoTopic(event);
        await dispatch(createTopic(topic));
        navigate("topic");
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="text" name="title" value={topic?.title}/>
                <input type="text" name="description" value={topic?.description}/>
                <input type="date" value={topic?.eventStart.toISOString()}/>
                <button type="submit">Изменить</button>
            </form>
            <button onClick={() => navigate("topic")}>Назад</button>
        </div>
    )
}