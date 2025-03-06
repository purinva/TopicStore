import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../../store/store";

function TopicList() {
    
    const topics = useSelector((state: RootState) => state.topic.items);
    const dispatch = useDispatch<AppDispatch>();

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
            <></>
        </div>
    )
}

export default TopicList;