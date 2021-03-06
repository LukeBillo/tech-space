import React, { FunctionComponent } from 'react';
import ReactMarkdown from 'react-markdown';
import { Link } from 'react-router-dom';
import { TechnologySpacePost } from '../../models/technology-space-post.model';

type PostProps = {
    post: TechnologySpacePost
};

export const PostTile: FunctionComponent<PostProps> = ({ post }) => {
    return (
    <div className={"Post bg-secondary-light rounded-md p-2"}>
        <h4 className={"post-title"}>
            <Link to={`/${post.provider}/post/${post.id}`}>{post.title} | {post.provider}</Link>
        </h4>
        <div className={"post-preview max-h-8 overflow-hidden"}>
            <ReactMarkdown source={post.content} />
        </div>
    </div>)
}
