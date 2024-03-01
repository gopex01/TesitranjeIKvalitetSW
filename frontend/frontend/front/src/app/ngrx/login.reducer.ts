import { createReducer, on } from "@ngrx/store";
import * as loginAction from "../ngrx/login.action"
export interface LoginState{
    username:string;
}
export const initialState:LoginState={
    username:''
};
export const loginReducer=createReducer(
    initialState,
    on(loginAction.setUsername,(state,{username})=>({
        ...state,
        username
    }))
);