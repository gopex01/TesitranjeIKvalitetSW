import { createFeature, createFeatureSelector, createSelector } from "@ngrx/store";
import { LoginService } from "../services/login.service";
import { LoginState } from "./login.reducer";

export const selectLoginState=createFeatureSelector<LoginState>('login');
export const selectUsername=createSelector(
    selectLoginState,
    (state)=>state.username
)