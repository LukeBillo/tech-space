import React from "react";
import { FunctionComponent } from "react";
import { TechnologySpacePost } from "../../models/technology-space-post.model";

export type PostViewProps = {
    post: TechnologySpacePost;
};

export const PostView: FunctionComponent = () => {
    return (
        <div className={"PostView"}>
            <p>Viewing post</p>
        </div>);
}