export interface Topic {
  topicId: string;
  title: string;
  description: string;
  eventStart: Date;
}

export interface TopicUpdateDto {
  topicId: string;
  title: string;
  description: string;
  eventStart: Date;
}

export interface TopicCreateDto {
  title: string;
  description: string;
  eventStart: Date;
}
  
export interface TopicState {
  items: Topic[];
  getTopicsError: string | null;
  createTopicError: string | null;
  updateTopicError: string | null;
  deleteTopicError: string | null;
}