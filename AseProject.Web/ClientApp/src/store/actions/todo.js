export const TODO_ACTIONS = {
    GET_ALL: 'todo.getAll',
    SET_ALL: 'todo.setAll',
    SET_LOADING: 'todo.setLoading',
    ADD: 'todo.add',
    CHECK: 'todo.check',
    DELETE: 'todo.delete',
};

export const TodoActions = {
    getAll: () => ({type: TODO_ACTIONS.GET_ALL}),
    setAll: (items) => ({type: TODO_ACTIONS.SET_ALL, payload: items}),
    setLoading: (loading) => ({type: TODO_ACTIONS.SET_LOADING, payload: loading}),
    add: (task) => ({type: TODO_ACTIONS.ADD, payload: task}),
    check: (id) => ({type: TODO_ACTIONS.CHECK, payload: id}),
    delete: (id) => ({type: TODO_ACTIONS.DELETE, payload: id}),
};