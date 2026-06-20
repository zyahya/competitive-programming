from .list_filtering import solution


def test_list_filtering():
    assert solution([1, 2, "a", "b"]) == [1, 2]
