import { createFeatureSelector, createSelector } from "@ngrx/store";
import { BCState } from "../reducer/bcname.reducer";

export const selectBCNameState=createFeatureSelector<BCState>('bcname');
export const selectBCName=createSelector(
    selectBCNameState,
    (state)=>state.BCName
)