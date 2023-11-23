import { UserTestDto } from '../../models/tests/userTestDto.model';
import { useGetTestsQuery } from '../../app/features/tests/test.api';
import useToken from '../../hooks/useToken';
import { TestPlate } from '../../components/test.plate';

function UserTestListComponent() {

    const { token, setToken } = useToken();
    const { data, isError, isLoading, error } = useGetTestsQuery(token!.userId);

    if (isLoading) {
        return <p>Loading...</p>;
    }

    if (isError) {
        return <p>Error: {error}</p>;
    }

    return (
        <>
            {data && data.length !== 0 ? data.map((userTest: UserTestDto) => {
                return <TestPlate key={userTest.testId} userTest={userTest} />
            })
                : <p>No tests</p>}
        </>

    );
}

export default UserTestListComponent;