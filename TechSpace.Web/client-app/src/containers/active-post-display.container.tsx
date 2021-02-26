import React from "react";
import { FunctionComponent, useEffect } from "react";
import { useParams } from "react-router-dom";
import { useActivePost } from "../hooks/active-post.context";
import { TechSpacesPostsClient } from "../http/tech-spaces-posts.http";
import {
  GenerateUniqueKeyForPost,
  TechnologySpacePost,
} from "../models/technology-space-post.model";
import { PostDisplay } from "../components/post-display/post-display.component";
import { useActiveSpace } from "../hooks/active-space.context";
import { TechSpacesClient } from "../http/tech-spaces.http";

export type ActivePostDisplayParams = {
  provider: string;
  postId: string;
};

const isCorrectActivePost = (
  provider: string,
  postId: string,
  activePost: TechnologySpacePost | null
) => activePost && activePost.source === provider && activePost.id === postId;

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

      if (fetchedPost.spaceId !== activeSpace?.identifier) {
        TechSpacesClient.get(fetchedPost.spaceId).then((fetchedSpace) => {
          setActiveSpace(fetchedSpace);
        });
      }
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
      {activePost && GenerateUniqueKeyForPost(activePost) === postId && (
        <PostDisplay post={activePost} />
      )}
    </>
  );
};
