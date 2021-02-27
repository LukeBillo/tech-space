import React from "react";
import { FunctionComponent, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useActivePost } from "../hooks/active-post.context";
import { TechSpacesPostsClient } from "../http/tech-spaces-posts.http";
import {
  GenerateUniqueKeyForPost,
  GenerateUniqueKeyForProviderAndPostId,
  TechnologySpacePost,
} from "../models/technology-space-post.model";
import { PostDisplay } from "../components/post-display/post-display.component";
import { useActiveSpace } from "../hooks/active-space.context";
import { FeedProvider } from "../models/feed-provider.enum";

export type ActivePostDisplayParams = {
  provider: FeedProvider;
  postId: string;
};

const isCorrectActivePost = (
  provider: string,
  postId: string,
  activePost: TechnologySpacePost | null
) => activePost && activePost.provider === provider && activePost.id === postId;

export const ActivePostDisplay: FunctionComponent = () => {
  const { provider, postId } = useParams<ActivePostDisplayParams>();
  const { activePost, setActivePost } = useActivePost();
  const { activeSpace, setActiveSpace } = useActiveSpace();

  useEffect(() => {
    if (isCorrectActivePost(provider, postId, activePost)) {
      return;
    }

    TechSpacesPostsClient.getById(provider, postId).then((fetchedPost) => {
      setActivePost(fetchedPost);
    });
  }, [
    activePost,
    activeSpace,
    postId,
    provider,
    setActivePost,
    setActiveSpace,
  ]);

  return (
    <>
      {activePost && GenerateUniqueKeyForPost(activePost) === GenerateUniqueKeyForProviderAndPostId(provider, postId) && (
        <PostDisplay post={activePost} />
      )}
    </>
  );
};
