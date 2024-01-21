import { createReducer, on } from "@ngrx/store";
import * as BCNameAction from "../action/bcname.action"
export interface BCState{
    BCName:string|undefined;
}

export const initialState:BCState={
    BCName:""
};

export const BCNameReducer=createReducer(
    initialState,
    on(BCNameAction.setBCName,(state,{BCName})=>({
        ...state,
        BCName
    }))
);