import {ACTIONS, Actions} from "../actions";
import {todoService} from "../../services";

async function getAllTodoItems(dispatch){
    try{
        dispatch(Actions.TodoActions.setLoading(true));
        const data = await todoService.getAllItems();
        dispatch(Actions.TodoActions.setAll(data));
    } catch (e) {
        console.error('Error getAllTodoItems: ', e);
    } finally {
        dispatch(Actions.TodoActions.setLoading(false));
    }
}

async function addTodoItem(dispatch, payload){
    try{
        dispatch(Actions.TodoActions.setLoading(true));
        await todoService.addNewItem(payload);
        await getAllTodoItems(dispatch);
    } catch (e) {
        console.error('Error addTodoItem: ', e);
    } finally {
        dispatch(Actions.TodoActions.setLoading(false));
    }
}

async function checkTodoItem(dispatch, payload){
    try{
        dispatch(Actions.TodoActions.setLoading(true));
        await todoService.checkItem(payload);
        await getAllTodoItems(dispatch);
    } catch (e) {
        console.error('Error checkTodoItem: ', e);
    } finally {
        dispatch(Actions.TodoActions.setLoading(false));
    }
}

async function deleteTodoItem(dispatch, payload){
    try{
        dispatch(Actions.TodoActions.setLoading(true));
        await todoService.deleteItem(payload);
        await getAllTodoItems(dispatch);
    } catch (e) {
        console.error('Error deleteTodoItem: ', e);
    } finally {
        dispatch(Actions.TodoActions.setLoading(false));
    }
}

export const TodoMiddleware = (dispatch, action) => {
    switch (action.type) {
        case ACTIONS.TODO.GET_ALL: return getAllTodoItems(dispatch, action.payload);
        case ACTIONS.TODO.ADD: return addTodoItem(dispatch, action.payload);
        case ACTIONS.TODO.CHECK: return checkTodoItem(dispatch, action.payload);
        case ACTIONS.TODO.DELETE: return deleteTodoItem(dispatch, action.payload);
        default: return dispatch;
    }
}