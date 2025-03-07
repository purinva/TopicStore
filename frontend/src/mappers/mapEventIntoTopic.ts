import { TopicCreateDto } from "../interfaces/topicInterface";

export const mapEventIntoTopic = (event: React.FormEvent<HTMLFormElement>) => {
    const formElements = event.currentTarget.elements
    const title = (formElements.namedItem("title") as HTMLInputElement).value;
    const description = (formElements.namedItem("description") as HTMLInputElement).value;
    const date = (formElements.namedItem("date") as HTMLInputElement).value;
    const topic: TopicCreateDto = {
        title: title,
        description: description,
        eventStart: new Date(date)
    }
    return topic;
}