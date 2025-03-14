import { TopicCreateDto, TopicUpdateDto } from "../interfaces/topicInterface";

export const mapEventIntoTopicCreateDto = (event: React.FormEvent<HTMLFormElement>) => {
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

export const mapEventIntoTopicUpdateDto = (event: React.FormEvent<HTMLFormElement>, topicId: string) => {
    const formElements = event.currentTarget.elements
    const title = (formElements.namedItem("title") as HTMLInputElement).value;
    const description = (formElements.namedItem("description") as HTMLInputElement).value;
    const date = (formElements.namedItem("date") as HTMLInputElement).value;
    const topic: TopicUpdateDto = {
        title: title,
        description: description,
        eventStart: new Date(date),
        topicId: topicId
    }
    return topic;
}