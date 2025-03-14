import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../store/store";
import { createTopic, deleteTopic, getTopics, getTotal } from "../../store/topicSlice";
import { authActions } from "../../store/authSlice";
import { useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import { mapEventIntoTopicCreateDto } from "../../mappers/mapEventIntoTopic";

export function TopicPage() {

    const topics = useSelector((state: RootState) => state.topic.items);
    const totalPages = useSelector((state: RootState) => state.topic.totalPages);
    const [currentPage, setCurrentPage] = useState(1);
    const createTopicError = useSelector((state: RootState) => state.topic.createTopicError);
    const dispatch = useDispatch<AppDispatch>();
    const navigate = useNavigate();

    useEffect(() => {
        dispatch(getTopics(currentPage));
        dispatch(getTotal());
    }, [dispatch, currentPage])

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const topic = mapEventIntoTopicCreateDto(event);
        await dispatch(createTopic(topic));
        await dispatch(getTopics(currentPage));
        await dispatch(getTotal());
    }

    const handleUpdate = (topicId: string) => {
        navigate(`/topic/${topicId}`);
    };    

    const handleDelete = async (topicId: string) => {
        const isConfirmed = window
            .confirm("Вы уверены, что хотите удалить эту тему?");
        if (isConfirmed) {
            await dispatch(deleteTopic(topicId));
            await dispatch(getTopics(currentPage));
            await dispatch(getTotal());
        }
    }

    return (
        <div>
            <div>
                <div>
                    <form onSubmit={handleSubmit}>
                        <input type="text" name="title" placeholder="Введите название"/>
                        <input type="text" name="description" placeholder="Введите описание"/>
                        <input type="date" name="date"/>
                        <button type="submit">Создать</button>
                    </form>
                    {createTopicError && <div>{createTopicError}</div>}
                </div>
                <button onClick={() => {
                    dispatch(authActions.logout());
                    navigate('/auth');
                    }}>Выйти</button>
            </div>
            <div>
                <ul>
                    {topics.map(topic => (
                        <li key={topic.topicId}>
                            <h3>{topic.title}</h3>
                            <p>{topic.description}</p>
                            <p>{new Date(topic.eventStart).toLocaleDateString()}</p>
                            <button onClick={() => handleUpdate(topic.topicId)}>Обновить</button>
                            <button onClick={() => handleDelete(topic.topicId)}>Удалить</button>
                        </li>
                    ))}
                </ul>
                <button onClick={() => {
                    if (currentPage > 1) {
                        setCurrentPage((prev) => prev - 1);
                    }
                }}>Назад</button>
                    Страница {currentPage} из {totalPages}
                <button onClick={() => {
                    if (currentPage < totalPages) {
                        setCurrentPage((prev) => prev + 1);
                    }
                }}>Вперед</button>  
            </div>
        </div>
    )
}