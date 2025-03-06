import { useEffect } from "react";
import { getTopics } from "../store/topicSlice";
import FormTopic from "../components/CreateTopicForm/CreateTopicForm";
import ButtonExit from "../components/ButtonExit/ButtonExit";
import TopicList from "../components/TopicList/TopicList";
import { AppDispatch } from "../store/store";
import { useDispatch } from "react-redux";

export function TopicLayout() {
    
    const dispatch = useDispatch<AppDispatch>();
    
    useEffect(() => {
		dispatch(getTopics());
	}, [dispatch]);

    return (
        <div>
            <div>
                <FormTopic/>
                <ButtonExit/>
            </div>
            <div>
                <TopicList/>                
            </div>
        </div>
    )
}