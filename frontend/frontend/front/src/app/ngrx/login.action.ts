import {createAction, props} from "@ngrx/store"
export const getUsername=createAction(
    '[User] get Username'
);
export const setUsername=createAction(
    '[User] Set username',
    props<{username:string}>()
);