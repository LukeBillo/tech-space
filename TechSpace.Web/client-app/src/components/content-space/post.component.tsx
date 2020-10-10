import React, { FunctionComponent } from 'react';
import ReactMarkdown from 'react-markdown';
import { TechnologySpacePost } from '../../shared/models/technology-space-post.model';

type PostProps = {
    post: TechnologySpacePost
};

export const Post: FunctionComponent<PostProps> = ({ post }) => {
    return (
    <div className={"Post bg-secondary-light rounded-md p-2"}>
        <h4 className={"post-title"}>
            {post.title} | {post.source}
        </h4>
        <div className={"post-preview max-h-8 overflow-hidden"}>
            <ReactMarkdown source={post.content} />
        </div>
    </div>)
}
