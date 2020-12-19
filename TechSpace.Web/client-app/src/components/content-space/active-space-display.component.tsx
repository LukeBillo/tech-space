import React, { FunctionComponent } from "react";
import { TechnologySpacePost } from "../../models/technology-space-post.model";
import { TechnologySpace } from "../../models/technology-space.model";
import { Post } from "./post.component";

export type ActiveSpaceProps = {
	activeSpace: TechnologySpace;
	posts: TechnologySpacePost[]
};

export const ActiveSpaceDisplay: FunctionComponent<ActiveSpaceProps> = ({ activeSpace, posts }) => {
	return (
		<div className="SpaceDisplay p-3">
			<div className="viewing-title text-center">
				<h4>You're viewing...</h4>
				<h2>{activeSpace.name}</h2>
			</div>
			<div className="space-posts grid grid-cols-3 grid-auto-rows-full gap-10 px-6 py-6">
				{posts.map(post => <Post key={post.key} post={post} />)}
			</div>
		</div>
	);
};