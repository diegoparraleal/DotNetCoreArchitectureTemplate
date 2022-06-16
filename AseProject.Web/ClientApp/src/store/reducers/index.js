import {TodoInitialState, TodoReducer} from "./todo";

export const InitialState = {
    todo: TodoInitialState
};

export const Reducer = (state = InitialState, action) => {
    return {
        ...state,
        todo: TodoReducer(state.todo, action)
    };
};