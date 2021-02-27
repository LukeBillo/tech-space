import React from "react";
import { FunctionComponent } from "react";
import { TechnologySpacePost } from "../../models/technology-space-post.model";

export type PostDisplayProps = {
    post: TechnologySpacePost;
};

export const PostDisplay: FunctionComponent<PostDisplayProps> = ({ post }) => {
    return (
        <div className={"PostDisplay"}>
            <p>Displaying post {post.title}</p>
        </div>);
}