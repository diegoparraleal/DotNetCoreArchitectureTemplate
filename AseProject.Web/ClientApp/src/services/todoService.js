import { default as axios} from 'axios';

export const todoService = {
    async getAllItems(){
        const response = await axios.get('api/todo');
        return response.data;
    },
    async addNewItem(task){
        const response = await axios.post('api/todo', { name: task });
        return response.data;
    },
    async checkItem(id){
        const response = await axios.put(`api/todo/${id}/check`);
        return response.data;
    },
    async deleteItem(id){
        const response = await axios.delete(`api/todo/${id}`);
        return response.data;
    }
};
