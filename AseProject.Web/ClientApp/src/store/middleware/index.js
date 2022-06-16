import {TodoMiddleware} from "./todo";

export const Middleware = async (dispatch, action) => {
    await TodoMiddleware(dispatch, action);
    return dispatch;
} 