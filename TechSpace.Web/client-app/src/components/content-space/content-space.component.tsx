import React, { FunctionComponent } from 'react';
import { Loading } from '../../shared/components/loading.component';
import { TechnologySpacePost } from '../../shared/models/technology-space-post.model';
import { TechnologySpace } from '../../shared/models/technology-space.model';
import { useSpaces } from '../../hooks/spaces.context';
import { Post } from './post.component';

export const ContentSpace = () => {
	const { activeSpace, spaces, postsForActiveSpace } = useSpaces();

	return (
		<div className="ContentSpace overflow-y-scroll flex-grow p-2">
			{spaces && activeSpace ? <ActiveSpaceDisplay activeSpace={activeSpace} posts={postsForActiveSpace} /> : <Loading />}
		</div>
	);
};

type ActiveSpaceProps = {
	activeSpace: TechnologySpace;
	posts: TechnologySpacePost[]
};

const ActiveSpaceDisplay: FunctionComponent<ActiveSpaceProps> = ({ activeSpace, posts }) => {
	return (
		<div className="SpaceDisplay p-3">
			<div className="viewing-title text-center">
				<h4>You're viewing...</h4>
				<h2>{activeSpace.name}</h2>
			</div>
			<div className="space-posts grid grid-cols-3 grid-auto-rows-full gap-10 px-6 py-6">
				{posts.map(post => <Post post={post} />)}
			</div>
		</div>
	);
};
