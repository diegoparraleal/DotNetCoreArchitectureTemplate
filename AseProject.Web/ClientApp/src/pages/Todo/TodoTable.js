import React, {useCallback, useContext} from "react";
import {ToggleButton} from "react-bootstrap";
import {Actions, Store} from "../../store";
import {Button} from "reactstrap";

export function TodoTable({items}){
    const context = useContext(Store);
    const dispatch = context.dispatch;

    const handleCheck = useCallback( (id) => dispatch(Actions.TodoActions.check(id)), [ dispatch ]);
    const handleDelete = useCallback( (id) => dispatch(Actions.TodoActions.delete(id)), [ dispatch ]);

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
            <tr>
                <th>Task</th>
                <th>Actions</th>
            </tr>
            </thead>
            <tbody>
            {items.map(item =>
                <tr key={item.id}>
                    <td>
                        <label style={{textDecoration: item.done ? "line-through": "initial"}}>{item.name}</label>
                    </td>
                    <td align="right">
                        {!item.done &&
                        <ToggleButton
                            variant="secondary"
                            type="checkbox"
                            checked={item.done}
                            value={item.id}
                            onClick={() => handleCheck(item.id)}
                        >
                            Finish
                        </ToggleButton>
                        }
                        <Button onClick={() => handleDelete(item.id)} style={{marginLeft: "16px"}}>Delete</Button>
                    </td>
                </tr>
            )}
            </tbody>
        </table>
    );
}