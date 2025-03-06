import { useDispatch, useSelector } from "react-redux"
import { AppDispatch, RootState } from "../store/store";
import { useEffect } from "react";
import { getTopics } from "../store/topicSlice";
import FormTopic from "../components/FormTopic/FormTopic";

export function TopicLayout() {
    
    const topics = useSelector((state: RootState) => state.topic.items);
    const dispatch = useDispatch<AppDispatch>();
    
    useEffect(() => {
		dispatch(getTopics());
	}, [dispatch]);

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
            <FormTopic/>
        </div>
    )
}