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
  topic: Topic | null;
  totalPages: number;
  getTopicsError: string | null;
  getTotalError: string | null;
  getTopicByIdError: string | null;
  createTopicError: string | null;
  updateTopicError: string | null;
  deleteTopicError: string | null;
}