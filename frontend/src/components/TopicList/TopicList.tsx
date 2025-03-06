import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../store/store";
import { useEffect, useState } from "react";
import { getTopics } from "../../store/topicSlice";

export function TopicList() {
    
    const topics = useSelector((state: RootState) => state.topic.items);
    const totalPages = useSelector((state: RootState) => state.topic.totalPages);
    const [currentPage, setCurrentPage] = useState(1);
    const dispatch = useDispatch<AppDispatch>();

    useEffect(() => {
        dispatch(getTopics(currentPage));
    }, [dispatch, currentPage])

    const handleNextPage = () => {
        if (currentPage < totalPages) {
            setCurrentPage((prev) => prev + 1);
        }
    };

    const handlePrevPage = () => {
        if (currentPage > 1) {
            setCurrentPage((prev) => prev - 1);
        }
    };

    return (
        <div>
            <ul>
                {topics.map((topic) => (
                    <li key={topic.topicId}>
                        {topic.title}
                        {topic.description}
                        {topic.eventStart.toISOString()}
                    </li>
                ))}
            </ul>
            <div>
                <button onClick={handleNextPage}/>
                    Страница {currentPage} из {totalPages}
                <button onClick={handlePrevPage}/>
            </div>
        </div>
    )
}