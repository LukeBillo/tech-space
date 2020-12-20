import React, { FunctionComponent } from "react";
import { GetUniquePostId, TechnologySpacePost } from "../../models/technology-space-post.model";
import { TechnologySpace } from "../../models/technology-space.model";
import { PostTile } from "./post-tile.component";

export type SpaceDisplayProps = {
	space: TechnologySpace;
	posts: TechnologySpacePost[]
};

export const SpaceDisplay: FunctionComponent<SpaceDisplayProps> = ({ space, posts }) => {
	return (
		<div className="SpaceDisplay p-3">
			<div className="space-posts grid grid-cols-3 grid-auto-rows-full gap-10 px-6 py-6">
				{posts.map(post => <PostTile key={GetUniquePostId(post)} post={post} />)}
			</div>
		</div>
	);
};