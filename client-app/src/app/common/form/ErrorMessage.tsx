import React from 'react';
import { AxiosResponse } from 'axios';
import { Message } from 'semantic-ui-react';

//dùng để tạo hộp thoại thông báo lỗi khi đăng nhập

interface IProps{
    error: AxiosResponse,
    text?: string;
}

const ErrorMessage:React.FC<IProps> = ({error, text}) => {
    return (
        <Message>
            <Message.Header>{error.statusText}</Message.Header>
            {text && <Message.Content content={text}/>}
        </Message>
    )
}

export default ErrorMessage;
