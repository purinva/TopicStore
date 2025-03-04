export interface Topic {
  topicId: string;
  title: string;
  description: number;
  eventStart: Date;
}

export interface TopicUpdateDto {
  topicId: string;
  title: string;
  description: number;
  eventStart: Date;
}

export interface TopicCreateDto {
  title: string;
  description: number;
  eventStart: Date;
}
  
export interface TopicState {
  items: Topic[];
  error: string | null;
}