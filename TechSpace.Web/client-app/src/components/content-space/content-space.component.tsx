import React, { FunctionComponent, useEffect } from 'react';
import { Loader } from '../shared/loading/loader.component';
import { useSpaces } from '../../hooks/spaces.context';
import { ActiveSpaceDisplay } from './active-space-display.component';
import { Redirect, Route, Switch, useParams } from 'react-router-dom';
import { PostView } from '../post-view/post-view.component';

type RouteParams = {
	spaceId: string | undefined;
	postId: string | undefined;
};

export const ContentSpace = () => {
	const { activeSpace, spaces, postsForActiveSpace, setActiveSpaceById } = useSpaces();
	const { spaceId, postId } = useParams<RouteParams>();

	useEffect(() => {
		if (spaceId && spaceId !== activeSpace?.identifier) {
			setActiveSpaceById(spaceId);
		}
	}, [spaceId, activeSpace])

	return (
		<div className="ContentSpace overflow-y-scroll flex-grow p-2">
			<Switch>
				<Route exact path='/'>
					{spaces && activeSpace && <Redirect to={{ pathname: `/space/${activeSpace.identifier}` }} />}
				</Route>
				<Route path={`/space/:spaceId`}>
					{spaces && activeSpace && postsForActiveSpace ? 
						<ActiveSpaceDisplay activeSpace={activeSpace} posts={postsForActiveSpace} /> : 
						<Loader />}
				</Route>
				<Route path={`/post/:postId`}>
					<PostView />
				</Route>
			</Switch>
		</div>
	);
};
