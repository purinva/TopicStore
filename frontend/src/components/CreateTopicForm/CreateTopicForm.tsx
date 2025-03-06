import { useDispatch, useSelector } from "react-redux";
import { TopicCreateDto } from "../../interfaces/topicInterface";
import { createTopic } from "../../store/topicSlice";
import { AppDispatch, RootState } from "../../store/store";

function FormTopic() {

    const error = useSelector((state: RootState) => state.topic.createTopicError);
    const dispatch = useDispatch<AppDispatch>();

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const formElements = event.currentTarget.elements
        const title = (formElements.namedItem("title") as HTMLInputElement).value;
        const description = (formElements.namedItem("description") as HTMLInputElement).value;
        const date = (formElements.namedItem("date") as HTMLInputElement).value;
        const topic: TopicCreateDto = {
            title: title,
            description: description,
            eventStart: new Date(date)
        }
        dispatch(createTopic(topic));
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="text" name="title" placeholder="Введите название"/>
                <input type="text" name="description" placeholder="Введите описание"/>
                <input type="date" name="date"/>
                <button type="submit">Создать</button>
            </form>
            {error && <div>{error}</div>}
        </div>
    )
}

export default FormTopic;