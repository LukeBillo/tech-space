import React from "react";
import { FunctionComponent, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useActivePost } from "../hooks/active-post.context";
import { TechSpacesPostsClient } from "../http/tech-spaces-posts.http";
import { GetUniquePostId } from "../models/technology-space-post.model";
import { PostDisplay } from "../components/post-display/post-display.component";

export type ActivePostDisplayParams = {
    provider: string;
    postId: string;
};

export const ActivePostDisplay: FunctionComponent = () => {
    const { provider, postId } = useParams<ActivePostDisplayParams>();
    const { activePost, setActivePost } = useActivePost();


    useEffect(() => {
        if (activePost && GetUniquePostId(activePost) === postId) {
            return;
        }

        TechSpacesPostsClient.getById(provider, postId).then(post => {
            setActivePost(post);
        });
    }, [provider, postId, activePost, setActivePost]);

    return (
        <div>
            {activePost && GetUniquePostId(activePost) === postId &&
                <PostDisplay post={activePost} />}
        </div>
    );
};
