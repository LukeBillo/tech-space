import { Reducer } from "react";
import { TechnologySpacePost } from "../../shared/models/technology-space-post.model";
import { TechnologySpace } from '../../shared/models/technology-space.model';
import { ActiveSpaceState } from './active-space.context';

export type SetActiveSpace = { type: 'set_active_space', payload: TechnologySpace };
export type SetLoadedPosts = { type: 'set_loaded_posts', payload: TechnologySpacePost[] }

export type ActiveSpaceAction = 
    SetActiveSpace |
    SetLoadedPosts;
    
export const ActiveSpaceReducer: Reducer<ActiveSpaceState, ActiveSpaceAction> = (state, action) => {
    switch (action.type) {
        case "set_active_space":
            return {
                activeSpace: action.payload,
                posts: [],
                isLoading: true
            };
        case "set_loaded_posts": 
            if (state === null) {
                return null;
            }

            return {
                activeSpace: state.activeSpace,
                posts: action.payload,
                isLoading: false
            };
    }
}

