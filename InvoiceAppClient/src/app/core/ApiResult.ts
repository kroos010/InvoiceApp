export interface ApiResult<T> {
    succeeded: boolean;
    // message: string;
    errors: ErrorMessage[];
    result: T;
}

export interface ErrorMessage {
    key: string;
    message: string;
}