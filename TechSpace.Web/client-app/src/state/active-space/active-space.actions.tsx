import { TechnologySpace } from '../../shared/models/technology-space.model';
import { TechSpacesPostsClient } from '../../http/tech-spaces-posts.http';
import { Dispatch } from 'react';
import { ActiveSpaceAction } from './active-space.reducer';

export const setActiveSpace = (activeSpace: TechnologySpace, dispatch: Dispatch<ActiveSpaceAction>) => {
    dispatch({ type: 'set_active_space', payload: activeSpace });
    getPostsForActiveSpace(activeSpace, dispatch);
}

const getPostsForActiveSpace = async (activeSpace: TechnologySpace, dispatch: Dispatch<ActiveSpaceAction>) => {
    const posts = await TechSpacesPostsClient.get(activeSpace.identifier);
    dispatch({ type: "set_loaded_posts", payload: posts });
}