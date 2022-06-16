import React, {useCallback, useContext, useEffect, useState} from 'react';
import {TodoTable} from "./TodoTable";
import {Actions, Store} from "../../store";
import {Button, Input, InputGroup} from "reactstrap";

export function Todo() {
  const context = useContext(Store);
  const dispatch = context.dispatch;
  const state = context.state;
  const todoItems = state.todo.items;
  const loading = state.todo.loading;
  const [task, setTask] = useState("");

  useEffect( () => {
    dispatch(Actions.TodoActions.getAll());
  }, [ dispatch ]);

  const handleOnChange = useCallback((ev) => setTask(ev.target.value), [ setTask ]);
  const handleOnClick = useCallback(() => {
    dispatch(Actions.TodoActions.add(task));
    setTask("");
  }, [ task, dispatch, setTask]);

  const contents = loading
    ? <p><em>Loading...</em></p>
    : <TodoTable items={todoItems} />;
  
  return (
    <div>
      <h1 id="tableLabel" >Todo items</h1>
      {contents}
      <InputGroup>
        <Input value={task} onChange={handleOnChange} />
        <Button onClick={handleOnClick}>Add new task</Button>
      </InputGroup>
    </div>
  );
}
