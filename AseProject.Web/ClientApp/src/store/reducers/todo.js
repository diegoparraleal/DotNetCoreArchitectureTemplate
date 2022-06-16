import {ACTIONS} from "../actions";

export const TodoInitialState = {
    items: [],
    loading: true
};

export const TodoReducer = (state = TodoInitialState, {type, payload}) => {
    switch (type) {
        case ACTIONS.TODO.SET_ALL: return {...state, items: payload};
        case ACTIONS.TODO.SET_LOADING: return {...state, loading: payload};
        default: return state;
    }
};