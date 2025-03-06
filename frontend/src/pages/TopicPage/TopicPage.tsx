import { ButtonExit } from "../../components/ButtonExit/ButtonExit";
import { FormTopic } from "../../components/CreateTopicForm/CreateTopicForm";
import { TopicList } from "../../components/TopicList/TopicList";

export function TopicPage() {
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