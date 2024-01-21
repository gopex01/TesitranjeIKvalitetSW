import { createAction, props } from "@ngrx/store";

export const getBCName=createAction(
    '[BCName] get BC name',
);
export const setBCName=createAction(
    '[BCName] set BC name',
    props<{BCName:string}>()
);
